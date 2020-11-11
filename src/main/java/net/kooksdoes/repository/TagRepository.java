package net.kooksdoes.repository;

import net.kooksdoes.domain.Tag;

import org.springframework.data.jpa.repository.*;
import org.springframework.stereotype.Repository;

import java.util.List;

/**
 * Spring Data  repository for the Tag entity.
 */
@SuppressWarnings("unused")
@Repository
public interface TagRepository extends JpaRepository<Tag, Long> {

    @Query("select tag from Tag tag where tag.assignedTo.login = ?#{principal.preferredUsername}")
    List<Tag> findByAssignedToIsCurrentUser();
}
